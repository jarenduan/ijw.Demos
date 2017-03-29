namespace ijw.Demo.Abilities {
    public class nodebase : Recievable {
        public string Name { get; set; }

        public nodebase() {
            this.RegisterRecieveAbility();
        }
    }
}
