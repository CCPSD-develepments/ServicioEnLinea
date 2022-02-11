namespace CamaraComercio.Website.UserControls
{
    /// <summary>
    /// Definicion para user controls de la oficina virtual
    /// </summary>
    public interface IOfvUserControl
    {
        /// <summary>
        /// Define si el control debe estar habilitado o no
        /// </summary>
        void Enable(bool enable);
    }
}