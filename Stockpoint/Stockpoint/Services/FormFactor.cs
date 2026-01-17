using Stockpoint.Shared.Services;

namespace Stockpoint.Services
{
    public class FormFactor : IFormFactor
    {
        public string GetFormFactor()
        {
            return DeviceInfo.Idiom.ToString();
        }

        public string GetPlatform()
        {
            return DeviceInfo.Platform.ToString() + " - " + DeviceInfo.VersionString;
        }


        private string _currentPage = "Inicio"; // Valor por defecto

        // Propiedad pública para acceder/modificar el nombre de la página
        public string CurrentPage
        {
            get => _currentPage;
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    OnPageChanged?.Invoke(); // Notificar a los suscriptores (ej: MainLayout)
                }
            }
        }

        // Evento para notificar cambios
        public event Action OnPageChanged;
    }
}
