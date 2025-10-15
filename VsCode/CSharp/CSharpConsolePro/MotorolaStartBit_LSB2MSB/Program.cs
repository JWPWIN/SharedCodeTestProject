class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(MotorolaStartBit_Lsb2Msb(25, 15));
    }

    /// <summary>
    /// Motorola格式起始位从LSB到MSB的转换
    /// </summary>
    /// <param name="startBit_Lsb">Lsb开始位</param>
    /// <param name="length">信号长度</param>
    /// <returns>Msb开始位</returns>
    static public int MotorolaStartBit_Lsb2Msb(int startBit_Lsb, int length)
    {
        int startBit_Msb;
        //信号未跨字节
        if (8 - startBit_Lsb % 8 >= length)
        {
            startBit_Msb = startBit_Lsb + length - 1;

        }
        else //信号跨字节
        {
            int lbsByteBits = 8 - startBit_Lsb % 8;//lsb所在字节位数 1
            int remainLen = length - lbsByteBits;//剩余长度 22
            int remainBytes = remainLen / 8;//剩余字节数 2
            int remainBits = remainLen % 8;//剩余位数 6
            startBit_Msb = startBit_Lsb - ((remainBytes + 1) * 8) - (startBit_Lsb % 8) + remainBits - 1;
        }

        return startBit_Msb;
    }

    /// <summary>
    /// Motorola格式起始位从MSB到LSB的转换
    /// </summary>
    /// <param name="startBit_Msb">Msb开始位</param>
    /// <param name="length">信号长度</param>
    /// <returns>Lsb开始位</returns>
    static public int MotorolaStartBit_Msb2Lsb(int startBit_Msb, int length)
    {
        int startBit_Lsb;
        //信号未跨字节
        if (startBit_Msb % 7 >= length)
        {
            startBit_Lsb = startBit_Msb - length + 1;

        }
        else //信号跨字节
        {
            int mbsByteBits = startBit_Msb % 7;//msb所在字节位数
            int remainLen = length - mbsByteBits;//剩余长度
            int remainBytes = remainLen / 8;//剩余字节数
            int remainBits = remainLen % 8;//剩余位数
            startBit_Lsb = startBit_Msb + ((remainBytes + 1) * 8) + (8 - startBit_Msb % 7) - remainBits;
        }

        return startBit_Lsb;
    }
}