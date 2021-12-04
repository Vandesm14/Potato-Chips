using LogicAPI.Server.Components;

namespace sv {
  public class OrGate : LogicComponent {
    protected override void DoLogicUpdate() {
      base.Outputs[0].On = base.Inputs[0].On || base.Inputs[1].On;
    }
  }
}
