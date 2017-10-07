using System.Text;
using System;
using System.Collections;

namespace Core
{
    public static class SearchName
    {
        public static ArrayList Search(string raw)
        {
            
            ArrayList names = new ArrayList();
            if (string.IsNullOrWhiteSpace(raw))
                return null;
            else
                raw = raw.ToUpperInvariant();
            ArrayList search = new ArrayList(); //database search should go here;
            foreach (var i in search)
            {
                if (i.ToString().Contains(raw)) {
                    names.Add(i);
                }
                
            }
            return names;
        }
    }
}
