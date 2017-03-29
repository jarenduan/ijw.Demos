using System;
using System.Collections.Generic;

namespace ijw.Demo.Abilities {
    public class ClassToMember<TClass, TMember> where TClass : class where TMember : new()  {
        private Dictionary<WeakReference<TClass>, TMember> Members = new Dictionary<WeakReference<TClass>, TMember>();

        public void Register(TClass obj) {
            ClearOneGarbages();
            this.Members.Add(new WeakReference<TClass>(obj), new TMember());
        }

        private void ClearOneGarbages() {
            WeakReference<TClass> key = null;
            foreach (var item in Members) {
                TClass target;
                if (item.Key.TryGetTarget(out target)) {
                    if (target == null) {
                        key = item.Key;
                    }
                }
            }
            if (key != null) {
                this.Members.Remove(key);
            }
        }

        public TMember GetMember(TClass obj) {
            WeakReference<TClass> target = null;

            foreach (var item in Members) {
                TClass abilityInPool;
                if (item.Key.TryGetTarget(out abilityInPool)) {
                    if (abilityInPool.Equals(obj)) {
                        target = item.Key;
                        break;
                    }
                }
            }

            if (target == null) {
                throw new Exception();
            }

            return Members[target];
        }
    }
}
