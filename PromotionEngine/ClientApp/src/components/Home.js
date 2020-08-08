import React, { Component } from 'react';
import CartCalculatorForm from './CartCalculatorForm.jsx'

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <CartCalculatorForm/>
      </div>
    );
  }
}
