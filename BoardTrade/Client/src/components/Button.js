import styled from 'styled-components'

export const Button = styled.button`
  border: none;
  border-radius: 4px;
  font-size: 16px;
  text-transform: uppercase;
  cursor: pointer;
  color: white;
  width: ${({ fullWidth }) => (fullWidth ? '100%' : 'auto')};
  min-width: 50px;
  min-height: 50px;
  display: flex;
  align-items: center;
  justify-content: center;
  border: none;
  background-color: ${({ theme }) => theme.colors.blue};
  outline: none;
  background-position: center;
  transition: background 0.5s;
  text-align: center;
  text-decoration: none;
  margin: ${({ fullWidth }) => (fullWidth ? '16px 0' : '16px')};

  svg {
    height: 20px;
    width: 20px;
    fill: white;
    color: white;
    margin: 0 6px;
  }

  :hover {
    background: ${({ theme }) => theme.colors.blueLight}
      radial-gradient(
        circle,
        transparent 1%,
        ${({ theme }) => theme.colors.blueLight} 1%
      )
      center/15000%;
  }

  :active {
    background-color: ${({ theme }) => theme.colors.blueLightest};
    background-size: 100%;
    transition: background 0s;
  }
`

export default Button
