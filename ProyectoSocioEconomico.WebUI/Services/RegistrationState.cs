namespace ProyectoSocioEconomico.WebUI.Services;

public class RegistrationState
{
    public bool Step1Completed { get; set; } = false;
    public bool Step2Completed { get; set; } = false;

    public void Reset()
    {
        Step1Completed = false;
        Step2Completed = false;
    }
}
