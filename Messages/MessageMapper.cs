using BmesRestApi.Messages.DataTransferObjects.Addresses;
using BmesRestApi.Messages.DataTransferObjects.Cart;
using BmesRestApi.Messages.DataTransferObjects.Customer;
using BmesRestApi.Messages.DataTransferObjects.Order;
using BmesRestApi.Messages.DataTransferObjects.Product;
using BmesRestApi.Models.Addresses;
using BmesRestApi.Models.Cart;
using BmesRestApi.Models.Customer;
using BmesRestApi.Models.Order;
using BmesRestApi.Models.Product;
using BmesRestApi.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Messages
{
    public class MessageMapper
    {
        public OrderItem MapToOrderItem(OrderItemDto orderItemDto)
        {
            var orderItem = new OrderItem();
            if (orderItemDto != null)
            {
                orderItem.Id = orderItemDto.IdDto;
                orderItem.CreatedDate = orderItemDto.CreatedDateDto;
                orderItem.IsDeleted = orderItemDto.IsDeletedDto;
                orderItem.ModifiedDate = orderItemDto.ModifiedDateDto;
                orderItem.OrderId = orderItemDto.OrderIdDto;
                orderItem.ProductId = orderItemDto.ProductDto.IdDto;
                orderItem.Quantity = orderItemDto.QuantityDto;

            }
            return orderItem;
        }
        public OrderItemDto MapToOrderItemDto(OrderItem orderItem)
        {
              OrderItemDto orderItemDto = null;
            if (orderItem?.Product != null)
            {
                var productDto = MapToProductDto(orderItem.Product);
                orderItemDto = new OrderItemDto
                {
                    IdDto = orderItem.Id,
                    CreatedDateDto = orderItem.CreatedDate,
                    IsDeletedDto = orderItem.IsDeleted,
                    ModifiedDateDto = orderItem.ModifiedDate,
                    OrderIdDto = orderItem.OrderId,
                    ProductDto = productDto,
                    QuantityDto = orderItem.Quantity
            };

            }
            return orderItemDto;
        }
        public Order MapToOrder (OrderDto orderDto)
        {
            var order = new Order();
            if(orderDto != null)
            {
                order.Id = orderDto.IdDto;
            order.ShippingCharge = orderDto.ShippingChargeDto;
            order.OrderStatus = (OrderStatus)orderDto.OrderStatusDto;
            order.AddressId = orderDto.AddressIdDto;
            order.CreatedDate = orderDto.CreatedDateDto;
            order.CustomerId = orderDto.CustomerIdDto;
            order.IsDeleted = orderDto.IsDeletedDto;
            order.ModifiedDate = orderDto.ModifiedDateDto;
            order.OrderItems = orderDto.OrderItemsDto;
            order.OrderItemTotal = orderDto.OrderItemTotalDto;
            order.OrderTotal = orderDto.OrderTotalDto;
        }
        return order;
        }
        public OrderDto MapToOrderDto(Order order)
        {
            var orderDto = new OrderDto();
            if(order != null)
            {
                orderDto.IdDto = order.Id;
                orderDto.ShippingChargeDto = order.ShippingCharge;
                orderDto.OrderStatusDto = (int)order.OrderStatus;
                orderDto.AddressIdDto = order.AddressId;
                orderDto.CreatedDateDto = order.CreatedDate;
                orderDto.CustomerIdDto = order.CustomerId;
                orderDto.IsDeletedDto = order.IsDeleted;
                orderDto.ModifiedDateDto = order.ModifiedDate;
                orderDto.OrderItemsDto = order.OrderItems;
                orderDto.OrderItemTotalDto = order.OrderItemTotal;
                orderDto.OrderTotalDto = order.OrderTotal;
            }
            return orderDto;

        }
        //***************************************** Mapping for Customer ******************************************************
        public Customer MapToCustomer (CustomerDto customerDto)
        {
            var person = new Person();
            if(customerDto != null)
            {
                person.CreatedDate = customerDto.CreatedDateDto;
                person.FirstName = customerDto.FirstNameDto;
                person.DateOfBirth = customerDto.DateOfBirthDto;
                person.EmailAddress = customerDto.EmailAddressDto;
                person.Gender = (Gender)customerDto.GenderDto;
                person.Id = customerDto.IdDto;
                person.IsDeleted = customerDto.IsDeletedDto;
                person.LastName = customerDto.LastNameDto;
                person.MiddleName = customerDto.MiddleNameDto;
                person.ModifiedDate = customerDto.ModifiedDateDto;
                person.PhoneNumber = customerDto.PhoneNumberDto;
            };
           
            return new Customer 
            { 
              Id = customerDto.IdDto,
              Person = person   
            };
        }
        public CustomerDto MpToCustomerDto(Customer customer)
        {
            var customerDto = new CustomerDto();
            if (customer != null)
            {
                customerDto.CreatedDateDto = customer.Person.CreatedDate;
                customerDto.FirstNameDto = customer.Person.FirstName;
                customerDto.DateOfBirthDto = customer.Person.DateOfBirth;
                customerDto.EmailAddressDto = customer.Person.EmailAddress;
                customerDto.GenderDto = (int)customer.Person.Gender;
                customerDto.IdDto = customer.Id;
                customerDto.IsDeletedDto = customer.Person.IsDeleted;
                customerDto.LastNameDto = customer.Person.LastName;
                customerDto.MiddleNameDto = customer.Person.MiddleName;
                customerDto.ModifiedDateDto = customer.Person.ModifiedDate;
                customerDto.PhoneNumberDto = customer.Person.PhoneNumber;
            };

            return customerDto;
        }
        public Person MpToPerson(PersonDto personDto)
        {
            var person = new Person();
            if (personDto != null)
            {
                person.CreatedDate = personDto.CreatedDateDto;
                person.FirstName = personDto.FirstNameDto;
                person.DateOfBirth = personDto.DateOfBirthDto;
                person.EmailAddress = personDto.EmailAddressDto;
                person.Gender = (Gender)personDto.GenderDto;
                person.Id = personDto.IdDto;
                person.IsDeleted = personDto.IsDeletedDto;
                person.LastName = personDto.LastNameDto;
                person.MiddleName = personDto.MiddleNameDto;
                person.ModifiedDate = personDto.ModifiedDateDto;
                person.PhoneNumber = personDto.PhoneNumberDto;
            };

            return person;
        }
        public PersonDto MpToPersonDto(Person person)
        {
            var personDto = new PersonDto();
            if (person != null)
            {
                personDto.CreatedDateDto = person.CreatedDate;
                personDto.FirstNameDto = person.FirstName;
                personDto.DateOfBirthDto = person.DateOfBirth;
                personDto.EmailAddressDto = person.EmailAddress;
                personDto.GenderDto = (int)person.Gender;
                personDto.IdDto = person.Id;
                personDto.IsDeletedDto = person.IsDeleted;
                personDto.LastNameDto = person.LastName;
                personDto.MiddleNameDto = person.MiddleName;
                personDto.ModifiedDateDto = person.ModifiedDate;
                personDto.PhoneNumberDto = person.PhoneNumber;
            };

            return personDto;
        }
        //***************************************** Mapping for Cart ******************************************************
        public Cart MapToCart (CartDto cartDto )
        {
            var cart = new Cart();
            if(cartDto != null)
            {
               
                cart.CartStatus = (CartStatus)cartDto.CartStatusDto;
                cart.CreatedDate = cartDto.CreatedDateDto;
                cart.IsDeleted = cartDto.IsDeletedDto;
                cart.ModifiedDate = cartDto.ModifiedDateDto;
                cart.Id = cartDto.IdDto;
                cart.UniqueCartId = cartDto.UniqueCartIdDto;
            }

            return cart;
        }
        public CartDto MaptoCartDto (Cart cart) 
        {
            var cartDto = new CartDto();
            if (cart != null)
            {
                cartDto.CartStatusDto = (int)cart.CartStatus;
                cartDto.CreatedDateDto = cart.CreatedDate;
                cartDto.IsDeletedDto = cart.IsDeleted;
                cartDto.ModifiedDateDto = cart.ModifiedDate;
                cartDto.IdDto = cart.Id;
                cartDto.UniqueCartIdDto = cart.UniqueCartId;
            }

            return cartDto;
        }
        public List<CartDto> MapToCartDtos (IEnumerable<Cart> carts)
        {
            List<CartDto> cartDtos = new List<CartDto>();

            foreach (var cart in carts)
            {
                cartDtos.Add(MaptoCartDto(cart));
            }
            return cartDtos;
        }

        public CartItem MapToCartItme (CartItemDto cartItemDto) 
        {
            var cartItem = new CartItem();

            if(cartItemDto != null)
            {
                cartItem.CartId = cartItemDto.CartIdDto;
                cartItem.CreatedDate = cartItemDto.CreatedDateDto;
                cartItem.Id = cartItemDto.IdDto;
                cartItem.IsDeleted = cartItemDto.IsDeletedDto;
                cartItem.ModifiedDate = cartItemDto.ModifiedDateDto;
                cartItem.Quantity = cartItemDto.QuantityDto;
                cartItem.ProductId = cartItemDto.productDto.IdDto;
            };
            return cartItem;
        }

        public CartItemDto MapToCartItmeDto (CartItem cartItem)
        {
            var cartItemDto = new CartItemDto();

            if (cartItemDto != null)
            {
                var productDto = MapToProductDto(cartItem.product);

                cartItemDto.CartIdDto = cartItem.CartId;
                cartItemDto.CreatedDateDto = cartItem.CreatedDate;
                cartItemDto.IdDto = cartItem.Id;
                cartItemDto.IsDeletedDto = cartItem.IsDeleted;
                cartItemDto.ModifiedDateDto = cartItem.ModifiedDate;
                cartItemDto.QuantityDto = cartItem.Quantity;
                cartItemDto.productDto = productDto;
            };
            return cartItemDto;
        }

        public List<CartItemDto> MapToCartItemDtos (IEnumerable<CartItem> cartItems)
        {
             var cartItemDtos = new List<CartItemDto>();

            foreach (var cartItem in cartItems)
            {
                var cartItemDto = MapToCartItmeDto(cartItem);
                cartItemDtos.Add(cartItemDto);
            }

            return cartItemDtos;
        }

        //***************************************** Mapping for Address ******************************************************
        public Address MapTopAddress (AddressDto addressDto) 
        {
            var address = new Address();
            if(addressDto != null)
            {
                address.State = addressDto.StateDto;
                address.AddressLine1 = addressDto.AddressLine1Dto;
                address.AddressLine2 = addressDto.AddressLine2Dto;
                address.City = addressDto.CityDto;
                address.ZipCode = addressDto.ZipCodeDto;
                address.Country = addressDto.CountryDto;
                address.CreatedDate = addressDto.CreatedDateDto;
                address.ModifiedDate = addressDto.ModifiedDateDto;
                address.Name = addressDto.NameDto;
                address.Id = addressDto.IdDto;
                address.IsDeleted = addressDto.IsDeletedDto;
            };

            return address;
        }

        public AddressDto MapTopAddressDto(Address address)
        {
            var addressDto = new AddressDto();
            if (address != null)
            {
                addressDto.StateDto = addressDto.StateDto;
                addressDto.AddressLine1Dto = address.AddressLine1;
                addressDto.AddressLine2Dto = address.AddressLine2;
                addressDto.CityDto = address.City;
                addressDto.ZipCodeDto = address.ZipCode;
                addressDto.CountryDto = address.Country;
                addressDto.CreatedDateDto = address.CreatedDate;
                addressDto.ModifiedDateDto = address.ModifiedDate;
                addressDto.NameDto = address.Name;
                addressDto.IdDto = address.Id;
                addressDto.IsDeletedDto = address.IsDeleted;
            };

            return addressDto;
        }

        public List<AddressDto> MapToAddressDtos (IEnumerable<Address> addresses)
        {
            List<AddressDto> addressDtos = new List<AddressDto>();
            foreach (var address in addresses)
            {
                var addressDto = MapTopAddressDto(address);
                addressDtos.Add(addressDto);
            }
            return addressDtos;
        }

        //***************************************** Mapping for Product ******************************************************
        public Brand MapToBrand  (BrandDto brandDto)
        {
            var brand = new Brand
            {
                Id = brandDto.IdDto,
                Name = brandDto.NameDto,
                Slug = brandDto.SlugDto,
                BrandStatus = (BrandStatus)brandDto.BrandStatusDto,
                MetaDescription = brandDto.MetaDescriptionDto,
                CreatedDate = brandDto.CreatedDateDto,
                Description =brandDto.DescriptionDto,
                IsDeleted = brandDto.IsDeletedDto,
                MetaKeywords = brandDto.MetaKeywordsDto,
                ModifiedDate = brandDto.ModifiedDateDto

            };
            return brand;
        }

        public BrandDto MapToBrandDto(Brand brand)
        {
            var brandDto = new BrandDto();
            if (brand != null)
            {

                brandDto.IdDto = brand.Id;
                brandDto.BrandStatusDto = (int)brand.BrandStatus;
                brandDto.SlugDto = brand.Slug;
                brandDto.CreatedDateDto = brand.CreatedDate;
                brandDto.DescriptionDto = brand.Description;
                brandDto.IsDeletedDto = brand.IsDeleted;
                brandDto.MetaDescriptionDto = brand.MetaDescription;
                brandDto.MetaKeywordsDto = brand.MetaKeywords;
                brandDto.ModifiedDateDto = brand.ModifiedDate;
                brandDto.NameDto = brand.Name;
                 
            }
            return brandDto;
        }

        public List<BrandDto> MapToBrandDtos (IEnumerable<Brand> brands) 
        {
            var bransDtos = new List<BrandDto>();
            foreach (var brand in brands)
            {
                var brandDto = MapToBrandDto(brand);
                bransDtos.Add(brandDto);
            }
            return bransDtos;
        }


        public Category MapToCategroy (CategoryDto categoryDto) 
        {

            var category = new Category();
            if(category != null)
            {
                category.Id = categoryDto.IdDto;
                category.Name = categoryDto.NameDto;
                category.Slug = categoryDto.SlugDto;
                category.CategoryStatus = (CategoryStatus)categoryDto.CategoryStatusDto;
                category.MetaDescription = categoryDto.MetaDescriptionDto;
                category.CreatedDate = categoryDto.CreatedDateDto;
                category.Description = categoryDto.DescriptionDto;
                category.IsDeleted = categoryDto.IsDeletedDto;
                category.MetaKeywords = categoryDto.MetaKeywordsDto;
                category.ModifiedDate = categoryDto.ModifiedDateDto;

            };
            return category;
        }
        public CategoryDto MapToCategroyDto(Category category)
        {
            var categoryDto = new CategoryDto();
            if (category != null)
            {

                categoryDto.IdDto = category.Id;
                categoryDto.CategoryStatusDto = (int)category.CategoryStatus;
                categoryDto.SlugDto = category.Slug;
                categoryDto.CreatedDateDto = category.CreatedDate;
                categoryDto.DescriptionDto = category.Description;
                categoryDto.IsDeletedDto = category.IsDeleted;
                categoryDto.MetaDescriptionDto = category.MetaDescription;
                categoryDto.MetaKeywordsDto = category.MetaKeywords;
                categoryDto.ModifiedDateDto = category.ModifiedDate;
                categoryDto.NameDto = category.Name;

            }
            return categoryDto;
        }

        public List<CategoryDto> MapToCategoryDtos (IEnumerable<Category> categories) 
        {
            var categoryDtos = new List<CategoryDto>();
            foreach (var category in categories)
            {
                var categoryDto = MapToCategroyDto(category);
                categoryDtos.Add(categoryDto);
            }

            return categoryDtos;
        }

        public Product MapToProduct (ProductDto productDto) 
        {
            var product = new Product
            {
                ProductStatus = (ProductStatus)productDto.ProductStatusDto,
                BrandId = productDto.BrandIdDto,
                CategoryId = productDto.CategoryIdDto,
                Description = productDto.DescriptionDto,
                CreatedDate = productDto.CreatedDateDto,
                SalePrice = productDto.SalePriceDto,
                SKU = productDto.SKUDto,
                Slug = productDto.SlugDto,
                QuantityInStock = productDto.QuantityInStockDto,
                Id = productDto.IdDto,
                ImageUrl = productDto.ImageUrlDto,
                IsBestseller = productDto.IsBestsellerDto,
                IsDeleted = productDto.IsDeletedDto,
                IsFeatured = productDto.IsFeaturedDto,
                MetaDescription = productDto.MetaDescriptionDto,
                MetaKeywords = productDto.MetaKeywordsDto,
                Model = productDto.ModelDto,
                ModifiedDate = productDto.ModifiedDateDto,
                Name = productDto.NameDto,
                OldPrice = productDto.OldPriceDto,
                Price = productDto.PriceDto
                
            };

            return product;
        }


        public ProductDto MapToProductDto(Product product)
        {
            var productDto = new ProductDto();

            if( product != null)
            {

                productDto.ProductStatusDto = (int)product.ProductStatus;
                productDto.BrandIdDto = product.BrandId;
                productDto.CategoryIdDto = product.CategoryId;
                productDto.DescriptionDto = product.Description;
                productDto.CreatedDateDto = product.CreatedDate;
                productDto.SalePriceDto = product.SalePrice;
                productDto.SKUDto = product.SKU;
                productDto.SlugDto = product.Slug;
                productDto.QuantityInStockDto = product.QuantityInStock;
                productDto.IdDto = product.Id;
                productDto.ImageUrlDto = product.ImageUrl;
                productDto.IsBestsellerDto = product.IsBestseller;
                productDto.IsDeletedDto = product.IsDeleted;
                productDto.IsFeaturedDto = product.IsFeatured;
                productDto.MetaDescriptionDto = product.MetaDescription;
                productDto.MetaKeywordsDto = product.MetaKeywords;
                productDto.ModelDto = product.Model;
                productDto.ModifiedDateDto = product.ModifiedDate;
                productDto.NameDto = product.Name;
                productDto.OldPriceDto = product.OldPrice;
                productDto.PriceDto = product.Price;
            }


            return productDto;
        }
        public List<ProductDto> MapToProductDtos(IEnumerable<Product> products) 
        {
            var productDtos = new List<ProductDto>();
            foreach (var product in products)
            {
                var productDto = MapToProductDto(product);
                productDtos.Add(productDto);
            }
            return productDtos;
        }
    }
}
