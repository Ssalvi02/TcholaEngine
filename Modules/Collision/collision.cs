using System;
using System.Collections.Generic;
using System.Text;

namespace COL
{
    class Collider
    {
        static public bool IsColiding(int pos1, int pos2)
        {
            if(pos1 == pos2)
            {
                return true;
            }
            return false;
        }
        static public bool IsColiding(int pos1, int pos2, int flag)
        {
            switch (flag)
            {
                case 1:
                    if(pos1 <= pos2)
                    {
                        return true;
                    }
                    return false;
                case 2:
                    if(pos1 < pos2)
                    {
                        return true;
                    }
                    return false;
                case 3:
                    if(pos1 >= pos2)
                    {
                        return true;
                    }
                    return false;
                case 4:
                    if(pos1 > pos2)
                    {
                        return true;
                    }
                    return false;
            }
            return false;
        }   
    }
}