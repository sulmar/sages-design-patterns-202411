using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    // Abstract Builder
    public interface IPresentationBuilder
    {
        void AddSlide(Slide slide);
    }

    // Concrete Builder A
    public class PDFPresentationBuilder : IPresentationBuilder
    {
        PdfDocument document = new PdfDocument();

        public void AddSlide(Slide slide)
        {
            document.AddPage(slide.Text);
        }

        public PdfDocument GetPdfDocument()
        {
            return document;
        }
    }

    // Concrete Builder B
    public class MoviePresentationBuilder : IPresentationBuilder
    {
        Movie movie = new Movie();

        public void AddSlide(Slide slide)
        {
            movie.AddFrame(slide.Text, 3);
        }

        public Movie GetMovie()
        {
            return movie;
        }
    }

    public class Slide
    {
        public string Text { get; }

        public Slide(string text)
        {
            Text = text;
        }
    }

    // Director
    public class Presentation
    {
        private List<Slide> slides = new List<Slide>();

        private IPresentationBuilder presentationBuilder;

        public Presentation(IPresentationBuilder presentationBuilder)
        {
            this.presentationBuilder = presentationBuilder;
        }

        public void AddSlide(Slide slide)
        {
            slides.Add(slide);
        }

        public void Export()
        {
            presentationBuilder.AddSlide(new Slide("Copyright"));

            foreach(Slide slide in slides)
            {
                presentationBuilder.AddSlide(slide);
            }                            
        }
    }

    public enum PresentationFormat
    {
        PDF,
        Image,
        PowerPoint,
        Movie
    }

    public class PdfDocument
    {
        public void AddPage(string text)
        {
            Console.WriteLine($"Add a page to PDF");
        }
    }

    public class Movie
    {
        public void AddFrame(string text, int duration)
        {
            Console.WriteLine($"Add a frame to the movie");
        }
    }
}
