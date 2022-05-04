namespace DDD.Shared.IntegrationEvents.Model
{
    public abstract class Pagination
    {
        private int _page = 1;
        private int _size = 10;
        public int Size
        {
            get { return _size; }
            set
            {
                if (value < 1)
                {
                    _size = 10;
                }
                else
                {
                    _size = (int)value;
                }
            }
        }
        public int Page
        {
            get { return _page; }
            set
            {
                if (value < 1)
                {
                    _page = 1;
                }
                else
                {
                    _page = (int)value;
                }
            }
        }

        public int Skip()
        {
            return (_page - 1) * _size;
        }
    }
}