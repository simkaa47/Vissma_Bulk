namespace Core.Models.Plc;

public class PlcModel
{
    public static List<object> Parameters { get; } = new List<object>();    
    public PlcSettingsModel Settings { get; } = new PlcSettingsModel();
    public PlcIndicationModel Indication { get; } = new PlcIndicationModel();
    public DiModel Di { get; } = new DiModel();

    public ErrorsModel Errors { get; } = new ErrorsModel(); 

    public DoModel Do { get; } = new DoModel();
    public PlcButtonCommandModel ButtonCommandsModel { get; } = new PlcButtonCommandModel();
    

}
