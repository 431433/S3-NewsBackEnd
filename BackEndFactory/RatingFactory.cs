using BackEndDAL;
using BackEndContract;

namespace BackEndFactory
{
    public static class RatingFactory
    {
        public static IRatingDAL RatingInterface()
        {
            return new RatingDAL();
        }
    }
}