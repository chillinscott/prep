using System.Collections;
using System.Collections.Generic;

namespace prep.collections
{
    public class ReadOnlyCollection<T> : IEnumerable<T>
    {
        readonly IList<T> _listItems;

        public ReadOnlyCollection(IList<T> listItems)
        {
            _listItems = listItems;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _listItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}