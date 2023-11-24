using Docker.DotNet;
using Docker.DotNet.Models;

namespace WheaterForeCast.Services
{
    public static class PostgresConfig
    {
        public static async Task CreatePostgresContainer()
        {
            using var client = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine"))
                                    .CreateClient();

            var createContainerParameters = new CreateContainerParameters
            {
                Image = "postgres:latest",
                Name = "my-postgres-container",
                Env = new List<string>
            {
                "POSTGRES_DB=your_database_name",
                "POSTGRES_USER=your_username",
                "POSTGRES_PASSWORD=your_password"
            },
                ExposedPorts = new Dictionary<string, EmptyStruct>
            {
                { "5432", default }
            },
                HostConfig = new HostConfig
                {
                    PortBindings = new Dictionary<string, IList<PortBinding>>
                {
                    {
                        "5432",
                        new List<PortBinding>
                        {
                            new PortBinding { HostIP = "127.0.0.1", HostPort = "5432" }
                        }
                    }
                }
                }
            };

            var response = await client.Containers.CreateContainerAsync(createContainerParameters);
            var containerId = response.ID;

            await client.Containers.StartContainerAsync(containerId, new ContainerStartParameters());

            Console.WriteLine($"PostgreSQL container '{containerId}' is running on port 5432");
        }
    }
}
