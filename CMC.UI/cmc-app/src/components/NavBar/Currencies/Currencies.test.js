import React from 'react';
import renderer from 'react-test-renderer';
import Currencies from './index';
import CurrencyContextProvider from '../../../contexts/CurrencyContext';

// beforeEach(() => {
// });

it('renders Currencies without crashing', () => {
  const component = renderer.create(
    <CurrencyContextProvider>
      <Currencies></Currencies>
    </CurrencyContextProvider>
  );
  let tree = component.toJSON();
  expect(tree).toMatchSnapshot();
});