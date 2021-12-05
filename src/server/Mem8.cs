using LogicAPI.Server.Components;
using LogicLog;

namespace sv {
  public class Mem8 : LogicComponent {
    private bool _clk {
      get {
        return base.Inputs[0].On;
      }
    }

    private bool _we {
      get {
        return base.Inputs[1].On;
      }
    }

    private bool _addr0 {
      get {
        return base.Inputs[2].On;
      }
    }

    private bool _addr1 {
      get {
        return base.Inputs[3].On;
      }
    }

    private bool _addr2 {
      get {
        return base.Inputs[4].On;
      }
    }

    private bool _addr3 {
      get {
        return base.Inputs[5].On;
      }
    }

    private bool _addr4 {
      get {
        return base.Inputs[6].On;
      }
    }

    private bool _addr5 {
      get {
        return base.Inputs[7].On;
      }
    }

    private bool _addr6 {
      get {
        return base.Inputs[8].On;
      }
    }

    private bool _addr7 {
      get {
        return base.Inputs[9].On;
      }
    }

    private bool _data0 {
      get {
        return base.Inputs[10].On;
      }
    }

    private bool _data1 {
      get {
        return base.Inputs[11].On;
      }
    }

    private bool _data2 {
      get {
        return base.Inputs[12].On;
      }
    }

    private bool _data3 {
      get {
        return base.Inputs[13].On;
      }
    }

    private bool _data4 {
      get {
        return base.Inputs[14].On;
      }
    }

    private bool _data5 {
      get {
        return base.Inputs[15].On;
      }
    }

    private bool _data6 {
      get {
        return base.Inputs[16].On;
      }
    }

    private bool _data7 {
      get {
        return base.Inputs[17].On;
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

    private bool _out7 {
      set {
        base.Outputs[7].On = value;
      }
    }

    public byte Addr {
      get {
        return (byte)(
          (byte)(_addr0 ? 1 : 0) |
          (byte)(_addr1 ? 2 : 0) |
          (byte)(_addr2 ? 4 : 0) |
          (byte)(_addr3 ? 8 : 0) |
          (byte)(_addr4 ? 16 : 0) |
          (byte)(_addr5 ? 32 : 0) |
          (byte)(_addr6 ? 64 : 0) |
          (byte)(_addr7 ? 128 : 0)
        );
      }
    }

    public byte Data {
      get {
        return (byte)(
          (this._data0 ? 1 : 0) |
          (this._data1 ? 2 : 0) |
          (this._data2 ? 4 : 0) |
          (this._data3 ? 8 : 0) |
          (this._data4 ? 16 : 0) |
          (this._data5 ? 32 : 0) |
          (this._data6 ? 64 : 0) |
          (this._data7 ? 128 : 0)
        );
      }
    }

    public byte Out {
      set {
        this._out0 = (value & 1) != 0;
        this._out1 = (value & 2) != 0;
        this._out2 = (value & 4) != 0;
        this._out3 = (value & 8) != 0;
        this._out4 = (value & 16) != 0;
        this._out5 = (value & 32) != 0;
        this._out6 = (value & 64) != 0;
        this._out7 = (value & 128) != 0;
      }
    }

    private bool edge = false; // saves the last clock edge
    private byte[] mem = new byte[256]; // memory

    protected override void DoLogicUpdate() {
      if (_clk) {
        if (edge == false) {
          edge = true;
          if (_we) {
            mem[Addr] = Data;
          }
          Out = mem[Addr];
        }
      } else {
        edge = false;
      }
    }
  }
}
