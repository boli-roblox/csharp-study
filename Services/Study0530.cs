using System.Collections.Generic;

namespace ProgramerStudy
{
    public abstract class Expression
    {
        public abstract double Evaluate( Dictionary<string, object> vars);
    }                                       

    public class Constant : Expression
    {
        double _value;
        public Constant(double value)
        {
            _value = value;
        }

        public override double Evaluate(Dictionary<string, object> vars)
        {
            return _value;
        }

    }

    public class Operation : Expression
    {
        Expression _left;
        char _op;
        Expression _right;

        public Operation(Expression left,char op,Expression right)
        {
            _left = left;
            _op = op;
            _right = right;
        }

        public override double Evaluate(Dictionary<string, object> vars)
        {
            throw new System.NotImplementedException();
        }
    }
}