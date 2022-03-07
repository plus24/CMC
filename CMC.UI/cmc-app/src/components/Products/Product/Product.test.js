import React from 'react';
import renderer from 'react-test-renderer';
import Product from './Product';
import {mount} from 'enzyme'
import enzymeConfig from '../../../enzymeConfig'
import CurrencyContextProvider from '../../../contexts/CurrencyContext'

const product={id:1,image:'', name:'test produc', price:10}
// beforeEach(() => {
// });

it('renders Product without crashing', () => {
  const component = renderer.create(
    <CurrencyContextProvider>
      <Product product={product} currency="AUD"></Product>
    </CurrencyContextProvider>
  );
  let tree = component.toJSON();
  expect(tree).toMatchSnapshot();
});

it('should have the correct currency sign in the price AUD $', function(){
  const component = mount(
    <CurrencyContextProvider currency="AUD">
      <Product product={product}></Product>
    </CurrencyContextProvider>
  );
  expect(component.find('.price').find('span').text()).toContain('$');
});

it('should have the correct currency sign in the price EUR €', function(){
  const component = mount(
    <CurrencyContextProvider currency="EUR">
      <Product product={product}></Product>
    </CurrencyContextProvider>
  );
  expect(component.find('.price').find('span').text()).toContain('€');
});