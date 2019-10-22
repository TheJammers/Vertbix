using HyperCasual.Utilities;
using UnityEngine;

namespace HyperCasual.Test
{
    /// <summary>
    /// Provides examples for the enum string utilities.
    /// </summary>
    [ExecuteInEditMode]
    public class TestEnumStringGenerators
        : MonoBehaviour
    {
        public bool Perform;

        public void OnDrawGizmos()
        {
            if (!Perform)
                return;
             
            Debug.Log(GenerateEnumString.CommaSeperated<TestEnum>());
            Debug.Log(GenerateEnumString.NewLineSeparated<TestEnum>());
            Perform = false;
        }

        public enum TestEnum
        {
            Value0,
            Value1,
            Value2,
        }
    }
}
