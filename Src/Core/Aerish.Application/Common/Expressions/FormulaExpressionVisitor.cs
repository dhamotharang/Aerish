using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Aerish.Application.Common.Expressions
{
    public static class Calculate
    {
        public static decimal Formula(string formula)
        {
            return 0;
        }
    }

    public enum OperatorAssociativity : byte
    {
        Left,
        Right
    }

    public enum TokenType : byte
    {
        Variable,
        Constant,
        Operator
    }

    public class Token
    {
        public TokenType Type { get; set; }

        public static Token Parse(string token)
        {
            if (Regex.IsMatch(token, @"^(\{.+?\})$"))
            {
                return new VariableToken
                {
                    Type = TokenType.Variable,
                    Name = token.Replace("{", "").Replace("}", ""),
                    Variable = token
                };
            }

            if (Regex.IsMatch(token, "^([0-9]+)$"))
            {
                return new ConstantToken
                {
                    Type = TokenType.Constant,
                    Value = decimal.Parse(token)
                };
            }

            return new OperatorToken
            {
                Type = TokenType.Operator,
                Operator = token,
                Precedence = new Func<int>(() =>
                {
                    if (token == "-" || token == "+")
                        return 2;
                    if (token == "/" || token == "÷" || token == "x" || token == "*")
                        return 3;
                    if (token == "^")
                        return 4;

                    return 0;
                }).Invoke(),
                Associativity = new Func<OperatorAssociativity>(() =>
                {
                    if (token == "-" || token == "+")
                        return OperatorAssociativity.Left;
                    if (token == "/" || token == "÷" || token == "x" || token == "*")
                        return OperatorAssociativity.Left;
                    if (token == "^")
                        return OperatorAssociativity.Right;

                    return OperatorAssociativity.Left;
                }).Invoke()
            };
        }
    }

    public class VariableToken : Token
    {
        /// <summary>
        /// Gets or sets the name of variable without curly brackets
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of variable with curly brackets
        /// </summary>
        public string Variable { get; set; }

        public override string ToString()
        {
            return Variable;
        }
    }

    public class ConstantToken : Token
    {
        public decimal Value { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public class OperatorToken : Token
    {
        public string Operator { get; set; }
        public int Precedence { get; set; }
        public OperatorAssociativity Associativity { get; set; }

        public override string ToString()
        {
            return Operator;
        }
    }

    public class FormulaExpressionVisitor : ExpressionVisitor
    {
        public T VisitFormulaExpression<T>(T param) where T : Expression
        {
            return (T)Visit(param);
        }

        public ParameterExpression ParameterExpression { get; set; }

        private IEnumerable<Token> getTokens(string formula)
        {
            Stack<Token> _retVal = new Stack<Token>();

            // https://en.wikipedia.org/wiki/Shunting-yard_algorithm
            // https://stackoverflow.com/a/49084069/403971
            Regex _regEx = new Regex(@"(\{.+?\}|[0-9]+|[+*\/\(\-\)])");
            Stack<OperatorToken> _operators = new Stack<OperatorToken>();

            var _matches = _regEx.Matches(formula);

            foreach (Match _match in _matches)
            {
                var _val = Token.Parse(_match.Value);

                if (_val is ConstantToken || _val is VariableToken)
                {
                    _retVal.Push(_val);
                    continue;
                }

                if (_val is OperatorToken)
                {
                    var _optToken = _val as OperatorToken;

                    if (_operators.Count == 0)
                        _operators.Push(_optToken);
                    else
                    {
                        var _topOprt = _operators.Peek();

                        if (_optToken.Operator == "(")
                        {
                            _operators.Push(_optToken);
                            continue;
                        }

                        if (_optToken.Operator == ")")
                        {
                            OperatorToken _openingPar = _operators.Pop();

                            while (_openingPar.Operator != "(")
                            {
                                _retVal.Push(_openingPar);
                                _openingPar = _operators.Pop();
                            }

                            continue;
                        }

                        if (_optToken.Precedence > _topOprt.Precedence)
                            _operators.Push(_optToken);
                        else
                        {
                            OperatorToken _lesserPrecedence = _operators.Peek();

                            while (_operators.Any() && _optToken.Precedence <= _lesserPrecedence.Precedence)
                            {
                                _retVal.Push(_operators.Pop());

                                if (_operators.Any()) _lesserPrecedence = _operators.Peek();
                            }

                            _operators.Push(_optToken);
                        }
                    }
                }
            }

            while (_operators.Any())
            {
                _retVal.Push(_operators.Pop());
            }

            return _retVal;
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            var _t = node.Method.DeclaringType;

            if (_t == typeof(Calculate))
            {
                var _arg = node.Arguments[0];
                var _expr = Expression.Lambda<Func<string>>(_arg).Compile().Invoke();
                var _tokens = getTokens(_expr);

                var _expressions = new Stack<Expression>();
                var _operatorTokens = new Stack<OperatorToken>();

                foreach (var _token in _tokens)
                {
                    switch (_token.Type)
                    {
                        case TokenType.Variable:
                            var _variableToken = (VariableToken)_token;
                            var _e2 = Expression.PropertyOrField(ParameterExpression, _variableToken.Name);
                            _expressions.Push(_e2);
                            break;
                        case TokenType.Constant:
                            var _constantToken = (ConstantToken)_token;
                            _expressions.Push(Expression.Constant(_constantToken.Value));
                            break;
                        case TokenType.Operator:
                            var _operatorToken = (OperatorToken)_token;
                            _operatorTokens.Push(_operatorToken);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                foreach (var _operator in _operatorTokens)
                {
                    var _right = _expressions.Pop();
                    var _left = _expressions.Pop();

                    switch (_operator.Operator)
                    {
                        case "+":
                            _expressions.Push(Expression.Add(_left, _right));
                            break;
                        case "-":
                            _expressions.Push(Expression.Subtract(_left, _right));
                            break;
                        case "*":
                        case "x":
                        case "X":
                            _expressions.Push(Expression.Multiply(_left, _right));
                            break;
                        case "/":
                            _expressions.Push(Expression.Divide(_left, _right));
                            break;
                    }
                }

                var _retVal = _expressions.SingleOrDefault();

                if (_retVal == null)
                {
                    throw new AerishException("Invalid formula");
                }

                return _retVal;
            }

            throw new AerishException("Invalid use of formula expression");
        }

        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            if (ParameterExpression == null) ParameterExpression = node.Parameters[0];

            return base.VisitLambda(node);
        }
    }
}
