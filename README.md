# PROG7312 POE - ST10067040 - Implementation Report

The below explains how to compile, use and run the Municipal Services Application. It describes the data structures used including their purpose and examples of how they improve the app's performance.

---

## How to Compile and Run the Application

### Requirements
1. **Visual Studio**: Install Visual Studio 2022 or newer.
2. **.NET Framework**: Ensure the .NET Framework 4.7.2 or higher is installed.
3. **Graphviz**: Install Graphviz (required for graph visualization). Add the `bin` folder of Graphviz to your system's PATH.

### Steps to Compile
1. Open the `.sln` file in Visual Studio.
2. Restore NuGet packages:
   - Right-click the solution and select **Restore NuGet Packages**.
3. Build the project:
   - Go to **Build** > **Build Solution** or press `Ctrl + Shift + B`.

### Steps to Run
1. Press `F5` to start debugging or `Ctrl + F5` to run the app without debugging.
2. The application will open with a menu to choose:
   - **Report Issues**
   - **Local Events and Announcements**
   - **Service Request Status**

---

## How to Use the Application

### Service Request Status Features
1. **Search and Filter Requests**:
   - Search requests by ID using the search box.
   - Filter by **Status**, **Location**, **Priority**, or a date range.
   - Sort by **Priority** in ascending or descending order.

2. **View Dependencies**:
   - Select a request and click **Show Selected Issue's Dependencies** to see its dependencies in a list.
   - Click **Visualize Selected Issue's Dependencies** to see the selected request's dependencies as a graph.

3. **Visualize All Dependencies**:
   - Click **Visualize All Dependencies** to show a graph of all requests and their relationships.

4. **Clear Filters**:
   - Reset all filters to their default values by clicking **Clear Filters**.

---

## Data Structures Used and Their Purpose

### 1. **Binary Search Tree (BST)**
   - **Purpose**: Stores service requests in a sorted order for easy retrieval.
   - **Example**: When displaying all service requests, the BST allows quick access to requests in order of their IDs.

   **Code Implementation**:
```csharp
// Binary Search Tree in Action
public List<ServiceRequest> InOrderTraversal()
{
    var result = new List<ServiceRequest>();
    InOrderTraversal(root, result);
    return result;
}

private void InOrderTraversal(Node node, List<ServiceRequest> result)
{
    if (node != null)
    {
        InOrderTraversal(node.Left, result);
        result.Add(node.Data);
        InOrderTraversal(node.Right, result);
    }
}
```
---

### 2. **AVL Tree**
- **Purpose**: Ensures efficient searching by keeping the tree balanced.
- **Example**: When looking for a specific request by ID, the AVL tree finds it quickly.

**Code Implementation**:
```csharp
// AVL Tree Search
public ServiceRequest FindRequest(int id)
{
    return dependencyTree.Search(new ServiceRequest { Id = id.ToString() });
}
```
---

### 3. **Red-Black Tree**
- **Purpose**: Handles bulk updates efficiently by keeping the tree balanced during insertions.
- **Example**: Used to process and organize large numbers of service requests effectively.
```csharp
// Red-Black Tree Insert
public void Insert(ServiceRequest request)
{
    root = Insert(request, root);
    root.Color = NodeColor.Black; // Ensures Red-Black balance
}
```
### 4. **Heaps**
-   **Purpose**: Helps sort service requests based on priority.
-   **Example**: If a user wants to sort requests by priority, heaps make this fast and efficient.
```csharp
// Priority Sorting with Heaps
var priorityHeap = new MinHeap<ServiceRequest>();
foreach (var request in allRequests)
{
    priorityHeap.Insert(request);
}
```
### 5. **Graph**

-   **Purpose**: Represents dependencies between service requests.
-   **Example**: Each service request is a node in the graph, and dependencies are shown as connections (edges) between nodes.
```csharp
// Adding Dependencies to Graph
foreach (var request in allRequests)
{
    dependencyGraph.AddNode(request);
}

sampleIssues[0].Dependencies.Add(sampleIssues[3]); // Issue 1 depends on Issue 4
sampleIssues[0].Dependencies.Add(sampleIssues[2]); // Issue 1 depends on Issue 3
```
### 6. **Graph Traversal (Breadth-First Search)**

-   **Purpose**: Finds all related requests by traversing the graph.
-   **Example**: If a request has dependencies, BFS lists all the connected requests.
```csharp
// Graph Traversal: BFS
public List<T> BreadthFirstTraversal(T startNode)
{
    var result = new List<T>();
    var queue = new Queue<T>();
    var visited = new HashSet<T>();

    queue.Enqueue(startNode);
    visited.Add(startNode);

    while (queue.Count > 0)
    {
        var current = queue.Dequeue();
        result.Add(current);

        foreach (var neighbor in adjacencyList[current])
        {
            if (!visited.Contains(neighbor))
            {
                visited.Add(neighbor);
                queue.Enqueue(neighbor);
            }
        }
    }
    return result;
}
```

## How These Data Structures Improve the Application

### Viewing Dependencies

-   **Scenario**: A user selects a request and visualizes its dependencies.
-   **How It Works**: The graph displays the selected request and all its dependent requests as connected nodes. BFS ensures all related requests are included.

### Sorting by Priority

-   **Scenario**: A user chooses **Sort by Priority: Ascending**.
-   **How It Works**: The heap organizes the requests by priority, updating the list to show the lowest-priority requests first.

### Fast Searching

-   **Scenario**: A user searches for a specific request by ID.
-   **How It Works**: The AVL Tree quickly finds the request by ID, saving time compared to a simple list search
