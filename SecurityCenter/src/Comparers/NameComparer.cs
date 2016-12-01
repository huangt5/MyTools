using System;
using System.Collections.Generic;
using System.Text;
using SecurityCenter.Entity;

namespace SecurityCenter.Comparers {
    class NameComparer : Comparer<BaseElement> {
        public override int Compare(BaseElement x, BaseElement y) {
            return string.Compare(x.Name, y.Name);
        }
    }
}
