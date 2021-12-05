using LogicAPI.Server.Components;
using LogicLog;

namespace sv {
  public class DLatch : LogicComponent {
    private bool _data {
      get {
        return base.Inputs[0].On;
      }
    }

    private bool _clk {
      get {
        return base.Inputs[1].On;
      }
    }

    private bool _out {
      set {
        base.Outputs[0].On = value;
      }
    }

    private bool mem = false; // memory
    private bool edge = false; // saves the last clock edge

    protected override void DoLogicUpdate() {
      if (_clk) {
        if (edge == false) {
          edge = true;
          mem = _data;
        }
      } else {
        edge = false;
      }
      _out = mem;
    }
  }
}
