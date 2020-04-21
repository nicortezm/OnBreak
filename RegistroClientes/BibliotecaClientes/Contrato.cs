using System;

public class Contrato
{
    public int NumContrato { get; set; }
    public Contrato()
	{
        this.init();
	}
    public void init()
    {
        NumContrato = 0;
    }
}
