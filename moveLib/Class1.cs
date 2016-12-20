using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csDmc1380;

namespace moveLib
{
    //潘浩 write in 2016-12-20
    public class MoveProbe
    {
        const int XCH = 0;
        const int YCH = 1;
        const int ZCH = 2;
        const double zeroX = 161.1;
        const double zeroY = 255.98;
        static double lastPointX = zeroX;
        static double lastPointY = zeroY;
        static bool isStart = false;
        static public int movePoint(double x, double y)
        {
            int nCard = 0;
            if (isStart == false)
            {
                nCard = Dmc1380.d1000_board_init(); //控制卡初始化
                isStart = true;
                if (nCard <= 0)
                    return 0;     //"未找到控制卡!", "警告"
            }
            if (Dmc1380.d1000_check_done(XCH) == 0 || Dmc1380.d1000_check_done(YCH) == 0 || Dmc1380.d1000_check_done(ZCH) == 0)
                return 0;//若在运行，则返回


            //Z轴返回
            int nAxis = ZCH;
            int nDir = -1;
            Dmc1380.d1000_set_pls_outmode(nAxis, 0);
            int nStart = 200;
            int nMSpeed = 1500;
            double nTAcc = 1.0;
            int nPulse = 5000;
            Dmc1380.d1000_start_t_move(nAxis, nPulse * nDir, nStart, nMSpeed, nTAcc);
            while (Dmc1380.d1000_check_done(ZCH) == 0) ;

            //X轴和Y轴开始运动
            double deltX = x - lastPointX;
            double deltY = y - lastPointY;
            lastPointX = x;
            lastPointY = y;
            int a = (int)(deltX * 10000.0 / 75.0);
            int b = (int)(deltY * 10000.0 / 75.0);
            nAxis = XCH;
            nStart = 500;
            nMSpeed = 3000;
            nTAcc = 2.0;

            while (nAxis <= 1)
            {
                if (nAxis == 0)
                    nPulse = a;
                else
                    nPulse = b;
                Dmc1380.d1000_set_pls_outmode(nAxis, 2);
                Dmc1380.d1000_start_t_move(nAxis, nPulse, nStart, nMSpeed, nTAcc);
                nAxis++;
            }
            while (Dmc1380.d1000_check_done(XCH) == 0 || Dmc1380.d1000_check_done(YCH) == 0) ;


            //Z轴开始运动
            nAxis = ZCH;
            nDir = 1;
            Dmc1380.d1000_set_pls_outmode(nAxis, 0);
            nStart = 200;
            nMSpeed = 1500;
            nTAcc = 1.0;
            nPulse = 5000;
            Dmc1380.d1000_start_t_move(nAxis, nPulse * nDir, nStart, nMSpeed, nTAcc);
            while (Dmc1380.d1000_check_done(ZCH) == 0) ;

            return 1;
        }
        static public void closeCard()
        {
            //backZero();
            movePoint(zeroX, zeroY);
            Dmc1380.d1000_board_close();    //关闭运动控制卡
        }
        static public void backZero()
        {

            int nAxis = XCH;
            int nDir = 1;
            int nStart = 500;
            int nMSpeed = 3500;
            double nTAcc = 2.0;
            int nPulse = 0;

            while (nAxis < 2)
            {
                nPulse = 0 - Dmc1380.d1000_get_command_pos(nAxis);
                Dmc1380.d1000_set_pls_outmode(nAxis, 2);
                Dmc1380.d1000_start_t_move(nAxis, nPulse * nDir, nStart, nMSpeed, nTAcc);
                nAxis++;
            }

            while (Dmc1380.d1000_check_done(XCH) == 0 || Dmc1380.d1000_check_done(YCH) == 0) ;
            for (int i = 0; i < 2; i++)
                Dmc1380.d1000_set_command_pos(i, 0);
        }

    }
}
