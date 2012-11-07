using System.Collections.Generic;

namespace prep.utility.filtering
{
    public class EnumerableFilteringExtensionPoint<TItemToFilter, TPropertyType> :
        IProvideAccessToCreatingMatchers<TItemToFilter, TPropertyType, IEnumerable<TItemToFilter>>
    {
        IEnumerable<TItemToFilter> original_set;
        IProvideAccessToCreatingMatchers<TItemToFilter, TPropertyType, IMatchAn<TItemToFilter>> match_creation_extension_point;

        public EnumerableFilteringExtensionPoint(IEnumerable<TItemToFilter> original_set,
                                                 IProvideAccessToCreatingMatchers
                                                     <TItemToFilter, TPropertyType, IMatchAn<TItemToFilter>>
                                                     match_creation_extension_point)
        {
            this.original_set = original_set;
            this.match_creation_extension_point = match_creation_extension_point;
        }

        public IProvideAccessToCreatingMatchers<TItemToFilter, TPropertyType, IEnumerable<TItemToFilter>> not
        {
            get { return new NegatingEnumerableFilteringExtensionPoint<TItemToFilter, TPropertyType>(this); }
        }

      public IEnumerable<TItemToFilter> creating_dsl_result_using(IMatchAn<TPropertyType> real_criteria)
        {
            return original_set.all_items_matching(match_creation_extension_point.creating_dsl_result_using(real_criteria));
        }
    }
}