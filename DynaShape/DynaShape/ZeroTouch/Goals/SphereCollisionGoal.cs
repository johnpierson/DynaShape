using Autodesk.DesignScript.Runtime;
using Autodesk.DesignScript.Geometry;

namespace DynaShape.ZeroTouch.Goals
{
    /// <summary>
    /// SphereCollisionGoal
    /// </summary>
    public  class SphereCollisionGoal
    {
        private SphereCollisionGoal(){}

        /// <summary>
        /// Maintain minimum distance between the nodes
        /// </summary>
        /// <param name="centers"></param>
        /// <param name="radii"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public static DynaShape.Goals.SphereCollisionGoal SphereCollisionGoal_Create(
            List<Point> centers,
            List<float> radii,
            [DefaultArgument("1.0")] float weight)
        {
            if (centers.Count != radii.Count)
                throw new Exception("Error: centers count is not equal to radii count");

            return new DynaShape.Goals.SphereCollisionGoal(centers.ToTriples(), radii, weight);
        }


        /// <summary>
        /// Maintain minimum distance between the nodes and the (static) lines
        /// </summary>
        /// <param name="goal"></param>
        /// <param name="radii"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public static DynaShape.Goals.SphereCollisionGoal SphereCollisionGoal_Change(
            DynaShape.Goals.SphereCollisionGoal goal,
            [DefaultArgument("null")] List<float> radii,
            [DefaultArgument("-1.0")] float weight)
        {
            if (radii != null)
            {
                if (goal.NodeCount != radii.Count)
                    throw new Exception("Error: radii count is not equal to node count");
                goal.Radii = radii.ToArray();
            }

            if (weight >= 0.0) goal.Weight = weight;
            return goal;
        }
    }
}