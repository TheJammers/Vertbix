using System.Collections;
using HyperCasual.Components;
using HyperCasual.Utilities;
using UnityEngine;

namespace HyperCasual.Data
{
    /// <summary>
    /// Represents a temporary process.
    /// </summary>
    public abstract class Process
    {
        public static T New<T>() where T : Process, new()
        {
            var process = new T();

            Debug.LogFormat("Process::Initializing::{0}", process.GetType().Name);
            process.Initialize();

            return process;
        }

        public Coroutine Perform()
        {
            return _flow.StartCoroutine(PerformStep());
        }

        public Coroutine StartCoroutine(IEnumerator step)
        {
            return _flow.StartCoroutine(step);
        }

        protected virtual void Initialize()
        {

        }

        private IEnumerator PerformStep()
        {
            Debug.LogFormat("Process::Performing::{0}", GetType().Name);
            yield return _flow.StartCoroutine(Step());

            Debug.LogFormat("Process::Finished::{0}", GetType().Name);
        }

        protected abstract IEnumerator Step();

        protected Process()
        {
            var entity = GenerateEntity.Perform(string.Format("Process_{0}", GetType().Name));
            _flow = entity.AddComponent<ProcessFlowComponent>();
        }

        private readonly ProcessFlowComponent _flow;
    }
}
