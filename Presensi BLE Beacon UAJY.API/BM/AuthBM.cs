using Presensi_BLE_Beacon_UAJY.API.DAO;
using Presensi_BLE_Beacon_UAJY.API.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Presensi_BLE_Beacon_UAJY.API.BM
{
    public class AuthBM
    {
        private AuthDAO dao;
        private OutPutApi output;

        public AuthBM()
        {
            dao = new AuthDAO();
            output = new OutPutApi();
        }

        // Login Mahasiswa
        public OutPutApi LoginMhs(string npm, string password)
        {
            var ul = dao.GetLoginMhs(npm);
            if (ul != null)
            {
                if (cekpassword(password, ul.PASSWORD))
                {
                    if (ul.KD_STATUS_MHS == "A")
                    {
                        var data = dao.GetProfileMhs(npm);

                        var tokenHandler = new JwtSecurityTokenHandler();
                        var key = Encoding.ASCII.GetBytes(AppSettings.secret);
                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[]
                            {
                                        new Claim(ClaimTypes.Name, data.NAMA_MHS),
                                        new Claim("NPM", data.NPM)
                            }),
                            Expires = DateTime.UtcNow.AddDays(7),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                        };
                        var token = tokenHandler.CreateToken(tokenDescriptor);
                        var gentoken = tokenHandler.WriteToken(token);

                        data.token = gentoken;

                        output.data = data;
                    }
                    else
                    {
                        output.error = "Gagal Login! Status Mahasiswa tidak aktif";
                        output.data = new { };
                    }
                }
                else
                {
                    output.error = "Gagal Login! Password salah";
                    output.data = new { };
                }
            }
            else
            {
                output.error = "Gagal Login! NPM Salah";
                output.data = new { };
            }

            return output;
        }

        // Login Dosen
        public OutPutApi LoginDsn(string npp, string password)
        {
            var ul = dao.GetLoginDsn(npp);            if (ul != null)
            {
                if (password == ul.PASSWORD)
                // if(cekpassword(password, ul.PASSWORD))
                {
                    if (ul.KD_STATUS_DOSEN == "A")
                    {
                        var data = dao.GetProfileDsn(npp);

                        var tokenHandler = new JwtSecurityTokenHandler();
                        var key = Encoding.ASCII.GetBytes(AppSettings.secret);
                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[]
                            {
                                        new Claim(ClaimTypes.Name, data.NAMA_DOSEN_LENGKAP),
                                        new Claim("NPP", data.NPP)
                            }),
                            Expires = DateTime.UtcNow.AddDays(7),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                        };
                        var token = tokenHandler.CreateToken(tokenDescriptor);
                        var gentoken = tokenHandler.WriteToken(token);

                        data.token = gentoken;

                        output.data = data;
                    }
                    else
                    {
                        output.error = "Gagal Login! Status Dosen tidak aktif";
                        output.data = new { };
                    }
                }
                else
                {
                    output.error = "Gagal Login! Password salah";
                    output.data = new { };
                }
            }
            else
            {
                output.error = "Gagal Login! NPP Salah.";
                output.data = new { };
            }

            return output;
        }

        // Login Admin
        public OutPutApi LoginAdm(string npp, string password)
        {
            var ul = dao.GetLoginAdm(npp);
            if (ul != null)
            {
                if (password == ul.PASSWORD)
                // if(cekpassword(password, ul.PASSWORD))
                {
                        var data = dao.GetProfileAdm(npp);

                        var tokenHandler = new JwtSecurityTokenHandler();
                        var key = Encoding.ASCII.GetBytes(AppSettings.secret);
                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[]
                            {
                                        new Claim(ClaimTypes.Name, data.NAMA_LENGKAP_GELAR),
                                        new Claim("NPP", data.NPP)
                            }),
                            Expires = DateTime.UtcNow.AddDays(7),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                        };
                        var token = tokenHandler.CreateToken(tokenDescriptor);
                        var gentoken = tokenHandler.WriteToken(token);

                        data.token = gentoken;

                        output.data = data;
                }
                else
                {
                    output.error = "Gagal Login! Password salah";
                    output.data = new { };
                }
            }
            else
            {
                output.error = "Gagal Login! NPP Salah.";
                output.data = new { };
            }

            return output;
        }

        // Fungsi Untuk Cek Password Yang Terenkripsi
        private bool cekpassword(string password, string passwordDatabase)
        {
            Encoding enc = Encoding.GetEncoding(1252);
            RIPEMD160 ripemdHasher = RIPEMD160.Create();
            byte[] data = ripemdHasher.ComputeHash(Encoding.Default.GetBytes(password));
            string str = enc.GetString(data);
            if (str == passwordDatabase)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}