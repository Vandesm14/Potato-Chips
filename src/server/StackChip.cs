using LogicAPI.Server.Components;
using LogicLog;

namespace potatochips {
  public class StackChip : LogicComponent {
    private bool _prev {
      get {
        return base.Inputs[0].On;
      }
    }

    private bool _next {
      get {
        return base.Inputs[1].On;
      }
    }

    private bool _write {
      get {
        return base.Inputs[2].On;
      }
    }

    private bool _data {
      get {
        return base.Inputs[3].On;
      }
    }

    private bool _out {
      set {
        base.Outputs[0].On = value;
      }
    }

    private bool[] mem = new bool[256];
    private int ptr = 0;

    protected override void DoLogicUpdate() {
      if (_write) {
        mem[ptr] = _data;
      }

      if (_prev && _next) {
        ptr = 0;
      } else if (_next) {
        ptr++;
        ptr = ptr % 256;
      } else if (_prev) {
        ptr--;
        if (ptr < 0) {
          ptr = 256 - 1;
        }
      }
      _out = mem[ptr];
    }
  }
}
