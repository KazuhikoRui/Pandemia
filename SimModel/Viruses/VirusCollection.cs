namespace SimModel.Viruses
{
    public static class VirusCollection
    {
        public static Virus VanillaVirus => new Vanilla228("Vanilla-228", true, 0.2f, 0f);
        public static Virus ChickenpoxVirus => new Chickenpox("Chickenpox", false, 0.7f, 0.0001f);
        public static Virus HirosumaVirus => new Hiroshima("Hiroshima", false, 0.75f, 0.7f);
        public static Virus TikotokoVirus = new Tikotoko("Tikotoko-XD", true, 0.3f, 0.05f);
    }
}
