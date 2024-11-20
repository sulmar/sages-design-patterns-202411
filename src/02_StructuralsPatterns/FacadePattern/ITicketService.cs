using FacadePattern.Models;
using FacadePattern.Repositories;
using FacadePattern.Services;
using System;

namespace FacadePattern;

public record class ConnectionOptions(string From, string To, DateTime When, byte NumberOfPlaces);

// Abstract Fasade
public interface ITicketService
{
    Ticket Buy(ConnectionOptions options);
    void Cancel(Ticket ticket);
}


// Concrete Fasade
public class PkpTicketService : ITicketService
{
    private readonly RailwayConnectionRepository railwayConnectionRepository;
    private readonly TicketCalculator ticketCalculator;
    private readonly ReservationService reservationService;
    private readonly PaymentService paymentService;
    private readonly EmailService emailService;

    public PkpTicketService(RailwayConnectionRepository railwayConnectionRepository, TicketCalculator ticketCalculator, ReservationService reservationService, PaymentService paymentService, EmailService emailService)
    {
        this.railwayConnectionRepository = railwayConnectionRepository;
        this.ticketCalculator = ticketCalculator;
        this.reservationService = reservationService;
        this.paymentService = paymentService;
        this.emailService = emailService;
    }

    public Ticket Buy(ConnectionOptions options)
    {
        RailwayConnection railwayConnection = railwayConnectionRepository.Find(options.From, options.To, options.When);
        decimal price = ticketCalculator.Calculate(railwayConnection, options.NumberOfPlaces);
        Reservation reservation = reservationService.MakeReservation(railwayConnection, options.NumberOfPlaces);
        Ticket ticket = new Ticket { RailwayConnection = reservation.RailwayConnection, NumberOfPlaces = reservation.NumberOfPlaces, Price = price };
        Payment payment = paymentService.CreateActivePayment(ticket);

        if (payment.IsPaid)
        {
            emailService.Send(ticket);
        }

        return ticket;
    }

    public void Cancel(Ticket ticket)
    {
        Payment payment = paymentService.CreateActivePayment(ticket);

        // Act
        reservationService.CancelReservation(ticket.RailwayConnection, ticket.NumberOfPlaces);
        paymentService.RefundPayment(payment);
    }
}


