import styled from 'styled-components'

const TextField = styled.input`
  border: 1px solid ${({ theme }) => theme.colors.grey};
  border-radius: 4px;
  padding: 16px;
  margin: ${({ fullWidth }) => (fullWidth ? '8px 0' : '8px')};
  min-height: 50px;
  min-width: 150px;
  width: ${({ fullWidth }) => (fullWidth ? '100%' : 'auto')};
  font-size: 14px;
  -webkit-appearance: none;

  :focus {
    background-color: ${({ theme }) => theme.colors.white};
    border-color: ${({ theme }) => theme.colors.blueLight};
    box-shadow: 0 0 2px ${({ theme }) => theme.colors.blueLight};
  }
`

export default TextField
