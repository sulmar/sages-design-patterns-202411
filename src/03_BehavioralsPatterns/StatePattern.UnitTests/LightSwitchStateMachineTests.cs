using Microsoft.VisualStudio.TestTools.UnitTesting;

using FSM = StatePattern.Models.FiniteStateMachine;

namespace StatePattern.UnitTests.StateMachine;

[TestClass]
public class LightSwitchTests
{
    [TestMethod]
    public void Init_WhenCalled_ShouldStateIsOff()
    {
        // Arrange

        // Act
        FSM.LightSwitch lightSwitch = new FSM.LightSwitch();

        // Assert
        Assert.AreEqual(FSM.LightSwitchState.Off, lightSwitch.State);

    }

    [TestMethod]
    public void Push_Once_ShouldStateIsOn()
    {
        // Arrange
        FSM.LightSwitch lightSwitch = new FSM.LightSwitch();

        // Act
        lightSwitch.Push();

        // Assert
        Assert.AreEqual(FSM.LightSwitchState.On, lightSwitch.State);
    }

    [TestMethod]
    public void PushDown_Twice_ShouldStateIsOff()
    {

        // Arrange
        FSM.LightSwitch lightSwitch = new FSM.LightSwitch();

        // Act
        lightSwitch.Push();
        lightSwitch.Push();

        // Assert
        Assert.AreEqual(FSM.LightSwitchState.Off, lightSwitch.State);
    }

}
