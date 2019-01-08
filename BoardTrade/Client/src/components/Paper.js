import styled from 'styled-components'

const Paper = styled.div`
  background: ${({ theme, secondary }) =>
    secondary ? 'transparent' : theme.colors.white};
  border: 1px solid ${({ theme }) => theme.colors.grey};
  border-radius: 6px;
  padding: 20px;
  margin: ${({ fullWidth }) => (fullWidth ? '10px 0' : '10px')};
  width: ${({ fullWidth }) => (fullWidth ? '100%' : 'auto')};
`

export default Paper
