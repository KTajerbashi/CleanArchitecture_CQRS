using BaseSource.Utilities.Models;

namespace BaseSource.Utilities.Extensions;

public static class RecursiveTreeExtensions
{
    public static List<TTree> RecursiveTree<TTree>(this List<TTree> list)
        where TTree : class, ITreeViewModel<TTree>
    {
        list.ForEach(r => r.Children = list.Where(ch => ch.ParentId == r.Id).ToList());

        return list.Where(i => i.ParentId == null).ToList();
    }
    public static List<TTree> RecursiveTree<TTree>(this IEnumerable<TTree> list)
            where TTree : class, ITreeViewModel<TTree>
    {
        // Convert to a list to avoid multiple enumeration
        var treeList = list.ToList();

        // Create a dictionary for fast lookup of children by ParentId
        var childrenLookup = treeList
                .GroupBy(item => item.ParentId)
                .ToDictionary(g => g.Key, g => g.ToList());

        // Assign children to each node
        treeList.ForEach(r => r.Children = childrenLookup.ContainsKey(r.Id) ? childrenLookup[r.Id] : new List<TTree>());

        // Return only root nodes (those with ParentId == null)
        return treeList.Where(i => i.ParentId == null).ToList();
    }

}