using Fluid;
using Fluid.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchardCore.Web1.Filters
{
    public class ArrayFilters
    {
        public static async ValueTask<FluidValue> Shuffle(FluidValue input, FilterArguments arguments, TemplateContext context)
        {
            if (arguments.Count > 0)
            {
                var member = arguments.At(0).ToStringValue();

                var values = new List<KeyValuePair<FluidValue, object>>();
                var rnd = new Random();
                foreach (var item in input.Enumerate())
                {
                    values.Add(new KeyValuePair<FluidValue, object>(item, (await item.GetValueAsync(member, context)).ToObjectValue()));
                }

                var orderedValues = values.OrderBy(item => rnd.Next())
                    .Select(x => x.Key)
                    .ToArray();

                return new ArrayValue(orderedValues);
            }
            else
            {
                return new ArrayValue(input.Enumerate().OrderBy(x => x.ToStringValue(), StringComparer.Ordinal).ToArray());
            }
        }

        public static async ValueTask<FluidValue> CheckResult(FluidValue input, FilterArguments arguments, TemplateContext context)
        {
            if (arguments.Count > 0)
            {
                var member = arguments.At(0).ToStringValue();

                var values = new List<KeyValuePair<FluidValue, object>>();
                var rnd = new Random();
                foreach (var item in input.Enumerate())
                {
                    values.Add(new KeyValuePair<FluidValue, object>(item, (await item.GetValueAsync(member, context)).ToObjectValue()));
                }

                var orderedValues = values.OrderBy(item => rnd.Next())
                    .Select(x => x.Key)
                    .ToArray();

                return new ArrayValue(orderedValues);
            }
            else
            {
                return new ArrayValue(input.Enumerate().OrderBy(x => x.ToStringValue(), StringComparer.Ordinal).ToArray());
            }
        }
    }
}
