namespace SimModel.Interfaces
{
    interface IVirus
    {
        string Code { get; } //Кодовое название 
        bool Reinfection { get; } //Перезаражаемость
        float Infection { get; } //Коэффициент заражения
        float Lethality { get; } //Коэффициент летальности
        int AgeToInfect { get; } //Возраст заражения
        int DayToRecover { get; } //Длительность болезни

        void Infect(Person person); //Метод заражения
        bool Death(Person person); //Метод летального исхода
    }
}
