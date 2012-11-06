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
                SampleInput = "6/nADD 1282352346 /test -";
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

    class FileEventParser
    {
        public string Parse(string sampleInput)
        {
            var lines = sampleInput.Split(new String[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder s = new StringBuilder();
            foreach (var line in lines)
            {
                var pieces = line.Split(' ');
                var command = line[0];
                var date = line[2];
                var folder = line[3];
                var fileOrDir = line[4];

                if (command.ToString() == "ADD")
                {
                    s.Append("Added");
                }

                

            }

        }
    }
}
