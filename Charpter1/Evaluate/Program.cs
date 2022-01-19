// input(1+((2+3)*(4*5)))   

var input = "(1+((2+3)*(4*5)))";
Evaluate(input);

void Evaluate(string input) {
    var ops = new Stack<char>();
    var valus = new Stack<float>();


    for (var i = 0; i < input.Length; i++) {
        var s = input[i];
        //Ignore left parentheses.
        if (s == '(') {
            continue;
        }

        //Push operands onto the operand stack.
        switch (s) {
            case '+':
                ops.Push(s);
                break;
            case '-':
                ops.Push(s);
                break;
            case '*':
                ops.Push(s);
                break;
            case '/':
                ops.Push(s);
                break;
            //On encountering a right parenthesis, pop an operator, pop the requisite number of operands,
            //and push onto the operand stack the result of applying that operator to those operands.
            case ')':
                var op = ops.Pop();
                var v = valus.Pop();
                switch (op) {
                    case '+':
                        v = valus.Pop() + v;
                        break;
                    case '-':
                        v = valus.Pop() - v;
                        break;
                    case '*':
                        v = valus.Pop() * v;
                        break;
                    case '/':
                        v = valus.Pop() / v;
                        break;
                }

                valus.Push(v);
                break;

            default:
                valus.Push(float.Parse(s.ToString()));
                break;
        }
    }

    Console.WriteLine(valus.Pop());
}