using Autodesk.DesignScript.Geometry;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace DynaShape.ZeroTouch.Goals
{
    /// <summary>
    /// OnCurveGoal
    /// </summary>
    public  class OnCurveGoal
    {
        private OnCurveGoal(){}

        /// <summary>
        /// Force a set of nodes to lie on the specified curve.
        /// </summary>
        /// <param name="startPositions"></param>
        /// <param name="targetCurve"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        [NodeCategory("Create")]
        public static DynaShape.Goals.OnCurveGoal Create(
            List<Point> startPositions,
            Curve targetCurve,
            [DefaultArgument("1.0")] float weight)
        {
            return new DynaShape.Goals.OnCurveGoal(startPositions.ToTriples(), targetCurve, weight);
        }


        /// <summary>
        /// Adjust the goal's parameters while the solver is running.
        /// </summary>
        /// <param name="goal"></param>
        /// <param name="targetCurve"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        [NodeCategory("Actions")]
        public static DynaShape.Goals.OnCurveGoal Change(
            DynaShape.Goals.OnCurveGoal goal,
            [DefaultArgument("null")] Curve targetCurve,
            float weight)
        {
            if (targetCurve != null) goal.TargetCurve = targetCurve;
            if (weight >= 0.0) goal.Weight = weight;
            return goal;
        }
    }
}
