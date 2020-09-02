using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RobotPipetting.Data
{
    public class RobotPipettingService
    {
        public IEnumerable<Command> ParseCommands(string commands)
        {
            var temp = new List<Command>();

            //get command lines
            //let lines = commands.match(/ ^.+$/ gm);
            var lines = Regex.Match(commands, "^((?<lines>.+?)((\r)?\n|$))+$").Groups["lines"].Captures.Select(x => x.Value);

            //parse each command line
            for (var i = 0; i < lines.Count(); i++)
            {
                var command = this.ParseLine(lines.ElementAt(i));

                if (command != null)
                {
                    temp.Add(command);
                }
            }

            return temp;
        }

        public Command ParseLine(string line)
        {
            //PLACE
            var match = Regex.Match(line, @"^(\t|\s)*PLACE\s+(\s*(\d)\s*\,\s*(\d)\s*)(\r\n)*$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

            if (match.Success)
            {
                return new Command { Name = CommandType.PLACE, Arguments = match.Groups[2].Captures[0].Value };
            }

            //DROP
            match = Regex.Match(line, @"^(\t|\s)*DROP\s*(\r\n)*$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

            if (match.Success)
            {
                return new Command { Name = CommandType.DROP, Arguments = "" };
            }

            //MOVE
            match = Regex.Match(line, @"^(\t|\s)*MOVE\s+([NSWE]{1})\s*(\r\n)*$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

            if (match.Success)
            {
                return new Command { Name = CommandType.MOVE, Arguments = match.Groups[2].Captures[0].Value };
            }

            return null;
        }

        public Location ParsePlaceArgs(string args)
        {
            var coords = Regex.Match(args, @"^\s*(\d)\s*\,\s*(\d)\s*$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

            if (coords.Success)
            {
                return new Location { X = int.Parse(coords.Groups[1].Captures[0].Value), Y = int.Parse(coords.Groups[2].Captures[0].Value) };
            }

            return null;
        }

        public Location ParseMoveArg (Location presentLocation, string arg)
        {
            arg = arg.ToUpper();

            var movement = (Movement)Enum.Parse(typeof(Movement), arg);

            switch (movement)
            {
                case Movement.N:
                    return new Location { X = presentLocation.X, Y = presentLocation.Y + 1 };
                case Movement.E:
                    return new Location { X = presentLocation.X + 1, Y = presentLocation.Y };
                case Movement.S:
                    return new Location { X = presentLocation.X, Y = presentLocation.Y - 1 };
                case Movement.W:
                    return new Location { X = presentLocation.X - 1, Y = presentLocation.Y };
                default:
                    return null;
            }
        }

    }
}
