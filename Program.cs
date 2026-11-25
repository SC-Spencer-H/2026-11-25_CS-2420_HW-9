// PART A
// 
// A1) 
// 0 -> [1,4]
// 1 -> [0,2,3]
// 2 -> [1,3]
// 3 -> [1,2,4]
// 4 -> [0,3,5]
// 5 -> [4]
//
// A2) 
//   0 1 2 3 4 5
// 0 0 1 0 0 1 0
// 1 1 0 1 1 0 0
// 2 0 1 0 1 0 0
// 3 0 1 1 0 1 0
// 4 1 0 0 1 0 1
// 5 0 0 0 0 1 0
//
// - 14 1's. 7 edges, 7x2 = 14. It's because the edges are undirected so each 
// - vertex stores the other vertex in the edge, which means two 1's per edge
//
// A3)
// 0 -> 2
// 1 -> 3
// 2 -> 2
// 3 -> 3
// 4 -> 3
// 5 -> 1
// 
// 2+3+2+3+3+1 = 14
// 
// A4) 
// 1. Removed: 0, Added: 1, 4, Queue: [1,4]
// 2. Removed: 1, Added: 2, 3, Queue: [4,2,3]
// 3. Removed: 4, Added: 5, Queue: [2,3,5]
// 4. Removed: 2, Added: none, Queue: [3,5]
// 5. Removed: 3, Added: none, Queue: [5]
// 6. Removed: 5, Added: none, Queue: []
// 
// Final BFS order: [0,1,4,2,3,5]
// 
// A5) 
// Deepest Call Stack: [0,1,2,3,4,5]
// Final DFS order: [0,1,2,3,4,5]
// 
// A6)
// Shortest Path: 2 -> 3 -> 4 -> 5
// Found by BFS since BFS moves outward like a ripple instead of taking winding detours like DFS
//
// A7) 
// Cycle: 0 -> 1 -> 2 -> 3 -> 4 -> 0
//
// A8)
// RemoveVertex(3)
// 0 -> [1,4]
// 1 -> [0,2]
// 2 -> [1]
// 4 -> [0,5]
// 5 -> [4]
// Still connected, 1, 2, and 4 each have edges or paths to 0
//
// A9) 
// - Adjacency Matrix: VxV cells, 10,000x10,000 = 10 billion cells
// - Adjacency Lists: V+E entries, 10,000+(10,000x30) = 310,000 entries
// Definitely use adjacency lists, an adjacency matrix only makes sense if all or almost all possible edges are used

internal class Program
{
    static void Main()
    {
        
    }
}