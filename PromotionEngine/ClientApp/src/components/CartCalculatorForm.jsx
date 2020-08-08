import React, { Component } from 'react';

export default class CartCalculatorForm extends Component {
    constructor(props) {
        super(props);
        this.state = {
            sum: 0,
            formValues: {
                a: 0,
                b: 0,
                c: 0,
                d: 0
            },
            error: ""
        };
        this.submit = this.submit.bind(this);
        this.handleChange = this.handleChange.bind(this);
    }

    submit() {
        fetch('api/CostCalculator/CalculateCost', {
            method: 'POST',
            body: JSON.stringify(this.state.formValues),
            headers: { 'Content-Type': 'application/json' }
        })
            .then(res => res.json())
            .catch(error => this.setState({ error: error }))
            .then(response => this.setState({ sum: response }));
    }

    handleChange(event) {
        var formValues = this.state.formValues;
        formValues[event.target.id] = event.target.value ? event.target.value : 0;
        this.setState({ formValues: formValues });
    }

    render() {
        return (
            <div>
                <h1>Cart Items</h1>

                <div>
                    <label>
                        A:
                        <input type="number" id="a" value={this.state.formValues.inputA} min={0} onChange={this.handleChange} />
                    </label>
                </div>
                <div>
                    <label>
                        B:
                        <input type="number" id="b" value={this.state.formValues.inputB} min={0} onChange={this.handleChange} />
                    </label>
                </div>
                <div>
                    <label>
                        C:
                        <input type="number" id="c" value={this.state.formValues.inputC} min={0} onChange={this.handleChange} />
                    </label>
                </div>
                <div>
                    <label>
                        D:
                        <input type="number" id="d" value={this.state.formValues.inputD} min={0} onChange={this.handleChange} />
                    </label>
                </div>
                <button className="btn btn-primary" onClick={this.submit}>Calculate</button>

                <div><b>Cart Total: {this.state.sum}</b></div>
                <div>Error: {this.state.error}</div>
            </div>
        );
    }
}