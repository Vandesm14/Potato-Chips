using LogicAPI.Server.Components;
using LogicLog;
using System;

namespace potatochips {
  public class ShiftRegister : LogicComponent {
    private bool _clk {
      get {
        return base.Inputs[0].On;
      }
    }

    private bool _data {
      get {
        return base.Inputs[1].On;
      }
    }

    private bool _out0 {
      set {
        base.Outputs[0].On = value;
      }
    }

    private bool _out1 {
      set {
        base.Outputs[1].On = value;
      }
    }

    private bool _out2 {
      set {
        base.Outputs[2].On = value;
      }
    }

    private bool _out3 {
      set {
        base.Outputs[3].On = value;
      }
    }

    private int _out {
      set {
        _out0 = Convert.ToBoolean((value & 0b1000) >> 3);
        _out1 = Convert.ToBoolean((value & 0b0100) >> 2);
        _out2 = Convert.ToBoolean((value & 0b0010) >> 1);
        _out3 = Convert.ToBoolean(value & 0b0001);
      }
    }

    private bool[] mem = new bool[4];

    protected override void DoLogicUpdate() {
      if (_clk) {
        mem[0] = mem[1];
        mem[1] = mem[2];
        mem[2] = mem[3];
        mem[3] = _data;
      }

      _out = (mem[0] ? 8 : 0) + (mem[1] ? 4 : 0) + (mem[2] ? 2 : 0) + (mem[3] ? 1 : 0);
    }
  }
}
