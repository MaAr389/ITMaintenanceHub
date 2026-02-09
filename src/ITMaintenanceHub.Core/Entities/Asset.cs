namespace ITMaintenanceHub.Core.Entities;

public enum AssetType
{
    WindowsServer,
    LinuxServer,
    HyperVHost,
    HyperVVM,
    IloManagement,
    NetworkSwitch,
    Firewall,
    Storage,
    Other
}

public enum Criticality
{
    Low,
    Medium,
    High,
    Critical
}

public class Asset
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Hostname { get; set; }
    public string? IpAddress { get; set; }
    public AssetType Type { get; set; }
    public Criticality Criticality { get; set; } = Criticality.Medium;
    
    // Zugehörigkeit
    public int NetworkId { get; set; }
    public Network Network { get; set; } = null!;
    
    // Zuständigkeiten
    public string? PrimaryOwnerId { get; set; }
    public ApplicationUser? PrimaryOwner { get; set; }
    public string? SecondaryOwnerId { get; set; }
    public ApplicationUser? SecondaryOwner { get; set; }
    
    // Patch-Status
    public DateTime? LastPatchDate { get; set; }
    public DateTime? NextPatchDate { get; set; }
    public string? CurrentFirmwareVersion { get; set; }
    public string? LatestFirmwareVersion { get; set; }
    public bool FirmwareUpdateRequired => 
        !string.IsNullOrEmpty(CurrentFirmwareVersion) && 
        !string.IsNullOrEmpty(LatestFirmwareVersion) && 
        CurrentFirmwareVersion != LatestFirmwareVersion;
    
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation
    public ICollection<PatchEntry> PatchHistory { get; set; } = new List<PatchEntry>();
    public ICollection<AssetComment> Comments { get; set; } = new List<AssetComment>();
}
