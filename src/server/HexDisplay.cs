using LogicAPI.Server.Components;
using LogicLog;
using System;

namespace potatochips {
  public class HexDisplay : LogicComponent {
    private bool _data0 {
      get {
        return base.Inputs[0].On;
      }
    }

    private bool _data1 {
      get {
        return base.Inputs[1].On;
      }
    }

    private bool _data2 {
      get {
        return base.Inputs[2].On;
      }
    }

    private bool _data3 {
      get {
        return base.Inputs[3].On;
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

    private bool _out4 {
      set {
        base.Outputs[4].On = value;
      }
    }

    private bool _out5 {
      set {
        base.Outputs[5].On = value;
      }
    }

    private bool _out6 {
      set {
        base.Outputs[6].On = value;
      }
    }

    private int _data {
      get {
        return (_data3 ? 1 : 0) + (_data2 ? 2 : 0) + (_data1 ? 4 : 0) + (_data0 ? 8 : 0);
      }
    }

    private int _out {
      set {
        _out0 = (value & 0x01) != 0;
        _out1 = (value & 0x02) != 0;
        _out2 = (value & 0x04) != 0;
        _out3 = (value & 0x08) != 0;
        _out4 = (value & 0x10) != 0;
        _out5 = (value & 0x20) != 0;
        _out6 = (value & 0x40) != 0;
      }
    }

    private byte[] table = new byte[] {
      0b01111110,
      0b00110000,
      0b01101101,
      0b01111001,
      0b00110011,
      0b01011011,
      0b01011111,
      0b01110000,
      0b01111111,
      0b01111011,
      0b01110111,
      0b00011111,
      0b01001110,
      0b00111101,
      0b01001111,
      0b01000111
    };

    protected override void DoLogicUpdate() {
      _out = table[_data];
    }
  }
}
