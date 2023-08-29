using backend_challenge.Modules.superpower.repository;
using backend_challenge.Modules.uniformColor.repository;

namespace backend_challenge.Modules.hero.repository;

public class Hero
{
    public Guid id { get; set; }
    public string name { get; set; } = null!;
    public string description { get; set; } = null!;
    public string? image { get; set; }
    public List<Superpower> superpower { get; set; }
    public UniformColor color { get; set; }
}