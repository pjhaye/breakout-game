using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace BreakoutGame
{
    public class CommandSequence
    {
        public event Action SequenceCompleted;

        private List<List<Command>> _sequence;
        private List<Command> _commandsLeft;

        public CommandSequence()
        {
            _sequence = new List<List<Command>>();
            _commandsLeft = new List<Command>();
        }

        public void Clear()
        {
            foreach(var command in _commandsLeft)
            {
                command.Completed -= OnCommandComplete;
            }

            _commandsLeft.Clear();
            _sequence.Clear();
        }

        public void AddParallel(List<Command> sequence)
        {
            _sequence.Add(sequence);
        }

        public void AddSequential(List<Command> commands)
        {
            foreach(var command in commands)
            {
                AddCommand(command);
            }
        }

        public void AddCommand(Command command)
        {
            _sequence.Add(new List<Command>{ command });
        }

        public void AppendCommand(Command command)
        {
            if(_sequence.Count == 0)
            {
                AddCommand(command);
                return;
            }

            if(_sequence[_sequence.Count - 1].Count == 0)
            {
                AddCommand(command);
                return;
            }

            _sequence[_sequence.Count - 1].Add(command);
        }

        public void AppendSequence(CommandSequence commandSequence)
        {
            _sequence.AddRange(commandSequence._sequence);                
        }

        public void Execute()
        {
            if(_commandsLeft.Count > 0)
            {
                _commandsLeft.Clear();
            }
            ExecuteNextSequence();
        }

        private void ExecuteNextSequence()
        {
            var size = _sequence.Count;
            if(size > 0)
            {
                var sequenceToExecute = _sequence[0];
                _sequence.RemoveAt(0);
                ExecuteSequence(sequenceToExecute);
            }
            else
            {
                if(SequenceCompleted != null)
                {
                    SequenceCompleted();
                }
            }
        }

        private void ExecuteSequence(List<Command> sequence)
        {
            foreach(var command in sequence)
            {
                _commandsLeft.Add(command);
                command.Completed += OnCommandComplete;
            }

            if(_commandsLeft.Count == 0)
            {
                ExecuteNextSequence();
            }
            else
            {
                var numCommandsLeft = _commandsLeft.Count;
                var commandsToExecute = new List<Command>();
                commandsToExecute.AddRange(_commandsLeft);
                for(var i = 0; i < numCommandsLeft; i++)
                {
                    var command = commandsToExecute[i];
                    command.Execute();
                }
            }
        }

        private void OnCommandComplete(Command command)
        {
            command.Completed -= OnCommandComplete;

            _commandsLeft.Remove(command);

            if(_commandsLeft.Count == 0)
            {
                OnSequenceComplete();
            }
        }

        private void OnSequenceComplete()
        {
            ExecuteNextSequence();
        }
    }
}