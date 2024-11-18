using System.Collections.Generic;

// ST10067040
public class DependencyTree
{
    private AVLTree<ServiceRequest> dependencyTree = new AVLTree<ServiceRequest>();

    // Add a service request to the dependency tree
    public void AddRequest(ServiceRequest request)
    {
        dependencyTree.Insert(request);
    }

    // Find a request by ID
    public ServiceRequest FindRequest(int id)
    {
        return dependencyTree.Search(new ServiceRequest { Id = id.ToString() });
    }

    // Get dependencies for a request
    public List<ServiceRequest> GetDependencies(ServiceRequest request)
    {
        return request?.Dependencies ?? new List<ServiceRequest>();
    }
}
