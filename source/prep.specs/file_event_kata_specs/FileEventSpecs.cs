using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace prep.specs.file_event_kata_specs
{
    class FileEventSpecs
    {
        public class when_given_a_series_of_file_events 
        {
            static int number_of_movies;

            Establish c = () =>
            {
                sut = new FileEventParser();
                SampleInput = "1\nADD 1282352346 /test -";
            };

            Because b = () =>
            {
                Result = sut.Parse(SampleInput);
            };
              

            It should_output_human_readable_output = () =>
            {
                Result.ShouldEqual("Added dir /test.");
            };

            static FileEventParser sut;
            static string Result;
            static string SampleInput;
        }
    }

    public class FileEvent
    {
        public string Command { get; set; }
        public string Date { get; set; }
        public bool IsDirectory { get; set; }
        public string EventCreatedResult { get; set; }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            if (Command == "ADD")
            {
                s.Append("Added");
            }
            if (IsDirectory)
            {
                s.Append(" dir " + EventCreatedResult);
            }

            s.Append(".");
            return s.ToString();
        }
    }

    public class LineEventParser
    {
        public static FileEvent Parse(string eventLine)
        {
            var pieces = eventLine.Split(' ');
            return new FileEvent(){Command = pieces[0], Date = pieces[1], EventCreatedResult = pieces[2], IsDirectory = pieces[3] == "-"};
        }
    }
    

    class FileEventParser
    {
        public string Parse(string sampleInput)
        {
            var lines = sampleInput.Split('\n');
            var numOfCommands = Convert.ToInt32(lines[0]);
            StringBuilder s = new StringBuilder();
            for (int i = 1; i <= numOfCommands; i++)
            {
                s.Append(LineEventParser.Parse(lines[i]).ToString());
            }
            return s.ToString();

        }
    }
}
