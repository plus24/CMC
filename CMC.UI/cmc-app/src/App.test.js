import React from 'react';
import renderer from 'react-test-renderer';
import App from './App';

test('renders App without crashing', () => {
  const component = renderer.create(
      <App currency="AUD"></App>
  );
  let tree = component.toJSON();
  expect(tree).toMatchSnapshot();
})