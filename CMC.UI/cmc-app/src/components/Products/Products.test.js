import React from 'react';
import renderer from 'react-test-renderer';
import Products from './Products';
import CurrencyContextProvider from '../../contexts/CurrencyContext'

// beforeEach(() => {
// });

it('renders Products without crashing', () => {
  const component = renderer.create(
    <CurrencyContextProvider>
      <Products currency="AUD"></Products>
    </CurrencyContextProvider>
  );
  let tree = component.toJSON();
  expect(tree).toMatchSnapshot();
});