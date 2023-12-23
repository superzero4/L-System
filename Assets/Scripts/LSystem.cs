﻿using Scripts.Rendering;
using Scripts.Sequence;
using Scripts.Sequence.Action;
using Scripts.Sequence.Context;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

namespace Scripts
{
    public class LSystem : LSystemBase<Context2D>
    {
        [SerializeField]
        private SpawnerRenderer _renderer;

        public override IRenderer<Context2D> Renderer => _renderer;

        public override IEActionToContextAction<Context2D> Traductor => _translator;
        public IEActionToContextAction<Context2D> _translator;
        protected override void Init()
        {
            _translator = new Translator2D(_settings.Delta);
        }
    }
}
